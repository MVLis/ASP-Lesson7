using System.Collections;
using ASP_Lesson7.Models;

namespace ASP_Lesson7.Controllers;

public class IndexModel
{
    public Dictionary<int,Product> Products { get; set; }

    public Product Product { get; set; } = new ();
    
    public int CurrentId { get; set; }

}