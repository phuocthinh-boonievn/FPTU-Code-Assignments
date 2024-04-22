using System;
using System.Collections.Generic;

namespace Equipments_Repository.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomName { get; set; } = null!;

    public string? Location { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
