using Cita.Models;
using System.Collections.Generic;
using System.Linq;
using Cita.Controllers;


namespace Cita.Services
{
    public static class CitaServices
    {
        static List<Cita> citas { get; }
        static int nextId = 3;

        public static List<Cita> GetAll() => citas;

        public static Cita Get(int id) => citas.FirstOrDefault(p => p.Id == id);

        public static void Add(Cita cita)
        {
            cita.Id = nextId++;
            citas.Add(cita);
        }

        public static void Delete(int id)
        {
            var cita = Get(id);
            if (cita is null)
                return;

            citas.Remove(cita);
        }

        public static void Update(Cita cita)
        {
            var index = citas.FindIndex(p => p.Id == cita.Id);
            if (index == -1)
                return;

            citas[index] = cita;
        }
    }
}