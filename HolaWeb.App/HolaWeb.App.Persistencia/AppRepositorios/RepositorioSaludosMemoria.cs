using System.Collections.Generic;
using HolaWeb.App.Dominio;
using System.Linq;
using System;



namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> saludos;

        public RepositorioSaludosMemoria()
        {
            saludos = new List<Saludo>()
            {
                new Saludo{Id=1,EnEspañol="Buenos Dias",EnIngles="Good Morning",EnItaliano="Bungiorno"},
                new Saludo{Id=2,EnEspañol="Buenas Tardes",EnIngles="Good Afternoon",EnItaliano="Buon pomeriggio"},
                new Saludo{Id=3,EnEspañol="Buenas Noches",EnIngles="Good Evening",EnItaliano="Buona notte"}

            };
        }
        public IEnumerable<Saludo> GetAll()
        {
            return saludos;
        }

        public Saludo GetSaludosPorId(int saludoId)
        {
            return saludos.SingleOrDefault(S => S.Id == saludoId);
        }
        
        public IEnumerable<Saludo> GetSaludosPorFiltro(string filtro = null) // la asignación filtro=null indica que el parámetro filtro es opcional
        {
            var saludos = GetAll(); // Obtiene todos los saludos
            if (saludos != null) //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    saludos = saludos.Where(s => s.EnEspañol.Contains(filtro));
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return saludos;
        }


    }
}