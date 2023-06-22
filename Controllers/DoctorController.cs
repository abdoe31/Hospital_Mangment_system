using BL;
using Microsoft.AspNetCore.Mvc;

namespace DAY4_7.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Idoctormanger doctormanger;

        public DoctorController(Idoctormanger idoctormanger) {
            this.doctormanger = idoctormanger;
        }

        public IActionResult Index( string id  )
        {
            var  view = doctormanger.veiwalldoctors(id).ToList();
           
            return View(view);
        }
        public IActionResult Delete (string id)
        {
            Guid x = new Guid(id);
            doctormanger.delete(x);
            return  RedirectToAction(nameof(Index));  
        }
        [HttpGet]
        public IActionResult Add()
        {
          
            return  View();
        }
        [HttpPost]
        public IActionResult Add(DoctorAddVM  doctor)
        {
            doctormanger.Add(doctor);
            
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(string id )
        {

            var iid = new Guid(id);
            var x = doctormanger.GetUpdateVM(iid);
            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(DoctorUpdateVM doctor)
        {
            doctormanger.Update(doctor);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(string id)
        {
            var iid = new Guid(id);
             var view = doctormanger.veiwadoctor(iid);
            return View(view);
        }

    }
}
