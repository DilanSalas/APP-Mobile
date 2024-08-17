using BigFood_service.Models;

namespace BigFood_service;

public partial class ProductosPage : ContentPage
{
    private Conexion _conexion;
    public ProductosPage()
	{

		InitializeComponent();
        _conexion = new Conexion();
        LoadProductos();
    }
    private async void LoadProductos()
    {
        var productos = await _conexion.ObtenerProductos();
        ProductosListView.ItemsSource = productos;
    }
    private async void OnExitButtonClicked(object sender, EventArgs e)
    {
            if (Navigation.NavigationStack.Count > 1)
            {
                await Navigation.PopAsync();
            }
            else
            {
                // Opcional: Maneja el caso donde no hay p�ginas anteriores en la pila de navegaci�n.
                await DisplayAlert("Aviso", "No hay m�s p�ginas a las que retroceder.", "OK");
            }
        }
}