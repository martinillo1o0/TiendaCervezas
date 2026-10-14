using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            // Reloj que se detiene. Mide el rendimiento de un algoritmo.
            Stopwatch stopwatch = Stopwatch.StartNew();

            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos concluida");
            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminado");
            Console.WriteLine("Todo ha finalizado");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mail terminado");
                return 1;
            });

            var task2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mail terminado");
                return 2;
            });

            Console.WriteLine("Hago otra cosa");
            var result1 = await task1;
            var result2 = await task2;

            Console.WriteLine("Todo ha terminado");
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed);

        }
    }
}
