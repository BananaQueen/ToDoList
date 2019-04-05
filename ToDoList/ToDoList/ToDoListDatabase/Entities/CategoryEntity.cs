using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CategoryEntity
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
}
