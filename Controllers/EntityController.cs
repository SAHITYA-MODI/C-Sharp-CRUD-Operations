using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/entities")]
public class EntityController : ControllerBase
{
    private readonly List<Entity> _entities;

    public EntityController(List<Entity> entities)
    {
        _entities = entities;
    }

    [HttpGet]
    public IActionResult GetEntities(
        [FromQuery] string search = "",
        [FromQuery] string gender = "",
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] List<string> countries = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "Id", // Default sort field is Id
        [FromQuery] string sortOrder = "asc") // Default sort order is ascending
    {
        var filteredEntities = _entities.AsQueryable(); // Convert to IQueryable for dynamic filtering

        // Search, Gender, Date range, and Country filters
        ApplyFilters(ref filteredEntities, search, gender, startDate, endDate, countries);

        // Sorting
        var sortedEntities = SortEntities(filteredEntities, sortBy, sortOrder);

        // Pagination
        var paginatedEntities = sortedEntities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(paginatedEntities);
    }

    private void ApplyFilters(
        ref IQueryable<Entity> entities,
        string search,
        string gender,
        DateTime? startDate,
        DateTime? endDate,
        List<string> countries)
    {
        // Search filter
        if (!string.IsNullOrWhiteSpace(search))
        {
            entities = entities.Where(e =>
                (e.Names != null && e.Names.Any(n =>
                    (n.FirstName != null && n.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                    (n.MiddleName != null && n.MiddleName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                    (n.Surname != null && n.Surname.Contains(search, StringComparison.OrdinalIgnoreCase)))) ||
                (e.Addresses != null && e.Addresses.Any(a =>
                    (a.Country != null && a.Country.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                    (a.AddressLine != null && a.AddressLine.Contains(search, StringComparison.OrdinalIgnoreCase)))) ||
                (e.Gender != null && e.Gender.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        // Gender filter
        if (!string.IsNullOrWhiteSpace(gender))
        {
            entities = entities.Where(e => e.Gender != null && e.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
        }

        // Date range filter
        if (startDate != null || endDate != null)
        {
            entities = entities.Where(e =>
                e.Dates != null && e.Dates.Any(d =>
                    (startDate == null || d.DateValue >= startDate) &&
                    (endDate == null || d.DateValue <= endDate)));
        }

        // Country filter
        if (countries != null && countries.Any())
        {
            entities = entities.Where(e =>
                e.Addresses != null && e.Addresses.Any(a =>
                    countries.Contains(a.Country, StringComparer.OrdinalIgnoreCase)));
        }
    }

    private IQueryable<Entity> SortEntities(IQueryable<Entity> entities, string sortBy, string sortOrder)
    {
        switch (sortBy.ToLower())
        {
            case "id":
                return sortOrder.ToLower() == "asc"
                    ? entities.OrderBy(e => e.Id)
                    : entities.OrderByDescending(e => e.Id);
            
            case "firstname":
                return sortOrder.ToLower() == "asc"
                    ? entities.OrderBy(e => e.Names.FirstOrDefault() != null ? e.Names.First().FirstName : null)
                    : entities.OrderByDescending(e => e.Names.FirstOrDefault() != null ? e.Names.First().FirstName : null);

            default:
                return entities; // Default to no sorting
        }
    }


    [HttpGet("{id}")]
    public IActionResult GetEntityById(string id)
    {
        var entity = _entities.Find(e => e.Id == id);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public IActionResult CreateEntity([FromBody] Entity newEntity)
    {
        newEntity.Id = Guid.NewGuid().ToString();
        _entities.Add(newEntity);

        return CreatedAtAction(nameof(GetEntityById), new { id = newEntity.Id }, newEntity);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEntity(string id, [FromBody] Entity updatedEntity)
    {
        var existingEntity = _entities.Find(e => e.Id == id);

        if (existingEntity == null)
        {
            return NotFound();
        }

        existingEntity.Names = updatedEntity.Names;
        existingEntity.Addresses = updatedEntity.Addresses;
        existingEntity.Dates = updatedEntity.Dates;
        existingEntity.Gender = updatedEntity.Gender;
        existingEntity.Deceased = updatedEntity.Deceased;

        return Ok(existingEntity);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEntity(string id)
    {
        var entityToDelete = _entities.Find(e => e.Id == id);

        if (entityToDelete == null)
        {
            return NotFound();
        }

        _entities.Remove(entityToDelete);

        return NoContent();
    }
}
