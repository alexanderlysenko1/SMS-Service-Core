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

        [Route("~/Phone/GetPhonesCount")]
        public int GetPhonesCount()
        {
            List<Phone> phones = _unitOfWork._phoneRepository.GetByUserId(_unitOfWork._userManager.GetUserId(User));
            return phones.Count;
        }

        [Route("~/Phone/GetPhones")]
        [HttpGet]
        public ICollection<Phone> GetPhones(int numberOfPage)
        {
            List<Phone> phones = _unitOfWork._phoneRepository.GetByUserId(_unitOfWork._userManager.GetUserId(User));
            return phones.Skip(numberOfPage * 10 - 10).Take(10).ToList();
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
            return new ObjectResult("Phone added successfully!");
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
            _unitOfWork.SaveChanges();
            return new ObjectResult("Phone modified successfully!");
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
            return new ObjectResult("Phone deleted successfully!");
        }

        [Route("~/Phone/Search/")]
        [HttpGet]
        public ICollection<Phone> Search(string searchData, int numberOfPage)
        {
            return _unitOfWork._phoneRepository.GetAll().Where(item => (item.PhoneNumber == searchData || item.FullName == searchData)).
                Skip(numberOfPage * 10 - 10).Take(10).ToList();
        }

        [Route("~/Phone/GetNumberOfSearchPhones/")]
        [HttpGet]
        public int GetNumberOfSearchPhones(string searchData)
        {
            return _unitOfWork._phoneRepository.GetAll().Where(item => (item.PhoneNumber == searchData || item.FullName == searchData)).Count();
        }
    }
}
