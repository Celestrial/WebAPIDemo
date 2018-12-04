using System.Data.Entity;

namespace WebApiDemo.Models
{
    public interface IWebApiDemoContext
    {
        DbSet<TODO> TODOes { get; set; }
    }
}