using VeterinariaAPI.Models;
using System.Text.Json;

namespace VeterinariaAPI.Services
{
    public class MascotaService
    {
        private readonly string _archivoMascotas = "mascotas.json";
        private List<Mascota> _mascotas;

        public MascotaService()
        {
            _mascotas = CargarMascotas();
        }

        private List<Mascota> CargarMascotas()
        {
            try
            {
                if (File.Exists(_archivoMascotas))
                {
                    var json = File.ReadAllText(_archivoMascotas);
                    return JsonSerializer.Deserialize<List<Mascota>>(json) ?? new List<Mascota>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar mascotas: {ex.Message}");
            }
            return new List<Mascota>();
        }

        private void GuardarMascotas()
        {
            try
            {
                var json = JsonSerializer.Serialize(_mascotas, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_archivoMascotas, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar mascotas: {ex.Message}");
            }
        }

        public List<Mascota> ObtenerTodas()
        {
            return _mascotas;
        }

        public Mascota? ObtenerPorCodigo(int codigo)
        {
            return _mascotas.FirstOrDefault(m => m.Codigo == codigo);
        }

        public Mascota Crear(Mascota mascota)
        {
            // Generar código automático si no se proporciona
            if (mascota.Codigo == 0)
            {
                mascota.Codigo = _mascotas.Count > 0 ? _mascotas.Max(m => m.Codigo) + 1 : 1;
            }

            _mascotas.Add(mascota);
            GuardarMascotas();
            return mascota;
        }

        public bool Actualizar(int codigo, Mascota mascota)
        {
            var mascotaExistente = ObtenerPorCodigo(codigo);
            if (mascotaExistente == null)
                return false;

            mascotaExistente.Nombre = mascota.Nombre;
            mascotaExistente.Raza = mascota.Raza;
            mascotaExistente.Localidad = mascota.Localidad;
            mascotaExistente.Calle = mascota.Calle;
            mascotaExistente.Altura = mascota.Altura;
            mascotaExistente.Descripcion = mascota.Descripcion;
            mascotaExistente.TipoMascota = mascota.TipoMascota;

            GuardarMascotas();
            return true;
        }

        public bool Eliminar(int codigo)
        {
            var mascota = ObtenerPorCodigo(codigo);
            if (mascota == null)
                return false;

            _mascotas.Remove(mascota);
            GuardarMascotas();
            return true;
        }
    }
}

