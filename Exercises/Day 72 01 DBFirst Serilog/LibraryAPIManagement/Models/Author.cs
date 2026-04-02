using System;
using System.Collections.Generic;

namespace LibraryAPIManagement.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    
}
