using Delivery.Models;

namespace Delivery.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Lanche> LanchesPreferidos { get; set; }
}
