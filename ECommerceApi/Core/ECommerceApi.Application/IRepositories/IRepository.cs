using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; set; }
}
