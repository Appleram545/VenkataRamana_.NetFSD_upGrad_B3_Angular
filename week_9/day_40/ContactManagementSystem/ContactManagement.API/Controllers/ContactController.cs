using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.Repository;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {


            return Ok(await _repo.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ContactInfo c)
        {
            await _repo.Add(c);

            return Ok(c);
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ContactInfo contact)
        {
            await _repo.Update(contact);
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);

            return Ok();
        }





    }
}