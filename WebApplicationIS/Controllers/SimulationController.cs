using Microsoft.AspNetCore.Mvc;
using WebApplicationIS.Models;

namespace TonProjet.Controllers
{
    public class SimulationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SimulationModel());
        }

        [HttpPost]
        public IActionResult Index(SimulationModel model)
        {
            model.Resultats = new List<PointResultat>();
            double t = 0;
            double N = model.N0;
            double r = model.R;
            double K = model.K;
            double dt = 1.0; // pas de temps
            int nombreEtapes = 30;

            for (int i = 0; i <= nombreEtapes; i++)
            {
                model.Resultats.Add(new PointResultat { Temps = t, Nombre = N });
                N = RungeKutta4(t, N, dt, r, K);
                t += dt;
            }

            return View(model);
        }

        private double Derive(double t, double N, double r, double K)
        {
            return r * N * (1 - N / K);
        }

        private double RungeKutta4(double t, double N, double h, double r, double K)
        {
            double k1 = h * Derive(t, N, r, K);
            double k2 = h * Derive(t + h / 2.0, N + h * k1 / 2.0, r, K);
            double k3 = h * Derive(t + h / 2.0, N + h * k2 / 2.0, r, K);
            double k4 = h * Derive(t + h, N + h * k3, r, K);

            return N + (h / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);
        }
    }
}
