using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoCompras
    {

        public string ID { get; set; }
        public int CantidadItems { get; set; }
        public List<Item> listaItems { get; set; }


        public CarritoCompras()
        {
            List<Item> lista = new List<Item>();
            listaItems = lista;
        }
        public double precioTotal()
        {
            double total = 0;
            foreach (var item in listaItems)
            {
                total += item.precio();
            }
            return total;
        }
        public void agregarItem(Articulo articulo)
        {
            Item newItem = new Item();
            if (listaItems.Count == 0)
            {
                newItem.ID = articulo.ID;
                newItem.Articulo = articulo;
                CantidadItems += 1;
                newItem.Cantidad += 1;
                listaItems.Add(newItem);
            }
            else
            {
                foreach (var item in listaItems)
                {
                    if (item.ID == articulo.ID)
                    {
                        item.Cantidad += 1;
                        CantidadItems += 1;
                    }
                    else
                    {
                        newItem.ID = articulo.ID;
                        newItem.Articulo = articulo;
                        newItem.Cantidad += 1;
                        CantidadItems += 1;
                        listaItems.Add(newItem);
                    }
                }
            }
        }
        public int getCantidad(int cantidad = 0)
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
