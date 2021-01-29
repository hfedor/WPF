using System;

namespace WPF.MVVM
{
    // interfejs do wioku modelu
    public interface IViewModel
    {
        // zamykanie widoku modelu 
        Action Close { get; set; }
    }
}
