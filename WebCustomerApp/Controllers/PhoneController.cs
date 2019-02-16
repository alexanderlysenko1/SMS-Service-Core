using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.PhoneViewModels;
using WebCustomerApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("Phone/[action]")]
    public class PhoneController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PhoneController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: /<controller>/
        public IActionResult Phones()
        {
            return View();
        }

        [Route("~/Phone/GetPhones")]
        [HttpGet]
        public ICollection<RecepientModel> GetPhones()
        {
            List<Phone> phones = _unitOfWork._phoneRepository.GetByUserId(_unitOfWork._userManager.GetUserId(User));
            List<RecepientModel> recepientModels = new List<RecepientModel>();
            foreach (var phone in phones)
            {
                RecepientModel recepientModel = new RecepientModel { id = phone.PhoneId, FullName = phone.FullName, PhoneNumber = phone.PhoneNumber };
                recepientModels.Add(recepientModel);
            }
            return recepientModels;
        }

        [HttpGet("{id}")]
        public RecepientModel Get(int id)
        {
            Phone phone = _unitOfWork._phoneRepository.GetById(id);
            RecepientModel recepientModel = new RecepientModel { id = phone.PhoneId, FullName = phone.FullName, PhoneNumber = phone.PhoneNumber };
            return recepientModel;
        }

        [Route("~/Phone/AddPhone")]
        [HttpPost]
        public IActionResult AddPhone(RecepientModel obj)
        {
            Phone phone = new Phone();
            phone.UserId = _unitOfWork._userManager.GetUserId(User);
            phone.PhoneNumber = obj.PhoneNumber;
            phone.FullName = obj.FullName;
            _unitOfWork._phoneRepository.Create(phone);
            _unitOfWork.SaveChanges();
            return new ObjectResult("Employee added successfully!");
        }

        [Route("~/Phone/UpdatePhone")]
        [HttpPut]
        public IActionResult UpdatePhone(RecepientModel obj)
        {
            Phone phone = new Phone();
            phone.PhoneId = obj.id;
            phone.UserId = _unitOfWork._userManager.GetUserId(User);
            phone.PhoneNumber = obj.PhoneNumber;
            phone.FullName = obj.FullName;
            _unitOfWork._phoneRepository.Update(phone);
            return new ObjectResult("Employee modified successfully!");
        }

        [Route("~/Phone/DeletePhone/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            List<RecepientMessage> recepientMessages = _unitOfWork._recepientMessageRepository.GetRecepientsMessagesByRecipientId(id);
            foreach (var recepientMessage in recepientMessages)
            {
                _unitOfWork._recepientMessageRepository.Delete(recepientMessage);
            }
            _unitOfWork._phoneRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return new ObjectResult("Employee deleted successfully!");
        }
    }
}
