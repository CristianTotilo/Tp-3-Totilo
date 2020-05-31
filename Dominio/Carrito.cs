using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public int ID { get; set; }
        public int CantidadItems { get; set; }
        public List<Item> listaItems { get; set; }
        public Carrito()
        {
            List<Item> lista = new List<Item>();
            listaItems = lista;
        }
        public double PrecioTotal()
        {
            double total = 0;
            foreach (var item in listaItems)
            {
                total += item.precio();
            }
            return total;
        }
        public void agregarItem(Articulo articulo, int cantidad)
        {
            Item item = new Item();
            CantidadItems += 1;
            item.Articulo = articulo;
            item.Cantidad = cantidad;
            item.ID = CantidadItems;
            listaItems.Add(item);
        }
        public int getCantidad(int cantidad=0)
        {
            foreach (var item in listaItems)
            {
                cantidad += item.Cantidad;
            }
            return cantidad;
        }

        public void eliminarItem(int ID)
        {
            foreach (var item in listaItems)
            {
                if (item.ID == ID)
                {
                    listaItems.Remove(item);
                    return;
                }
            }
        }
    }
}
