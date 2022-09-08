using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolaWeb.App.Dominio;
using HolaWeb.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolaWeb.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
        //private string [] saludos = {"Buenos Dias","Buenas Tardes","Buenas Noches","Hasta Mañana"};

        //public List<string> ListaSaludos {get;set;}

        private readonly IRepositorioSaludos repositorioSaludos;

        public IEnumerable<Saludo> Saludos { get; set; }

        public string? FiltroBusqueda { get; set; }

        public ListModel(IRepositorioSaludos repositorioSaludos)
        {
            this.repositorioSaludos = repositorioSaludos;
        }
        public void OnGet(string filtroBusqueda)
        {
            //ListaSaludos = new List<string>();
            //ListaSaludos.AddRange(saludos);
            FiltroBusqueda = filtroBusqueda;

            Saludos = repositorioSaludos.GetSaludosPorFiltro(filtroBusqueda);

        }
    }
}
