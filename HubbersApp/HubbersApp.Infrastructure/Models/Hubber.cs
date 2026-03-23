using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HubbersApp.Infrastructure.Models;

public class Hubber
{
    [Key, Comment("Hub Id")] public Guid Id { get; set; }

    [Required, MaxLength(50), Comment("Hub Member Name")]
    public string Name { get; set; } = null!;
}