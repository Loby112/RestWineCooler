using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestWineCooler.Managers;
using WineCoolerLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWineCooler.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WineCoolersController : ControllerBase{
        private WineCoolersManager manager = new WineCoolersManager();
        // GET: api/<WineCoolersController>
        [HttpGet]
        public ActionResult<IEnumerable<WineCooler>> Get(){
            return Ok(manager.GetAllCoolers());
        }

        // GET api/<WineCoolersController>/5
        [HttpGet("{id}")]
        public ActionResult<WineCooler> Get(int id){
            WineCooler result = manager.GetCooler(id);
            if (result == null){
                return NotFound(id);
            }
            return Ok(result);
        }

        // POST api/<WineCoolersController> 
        [HttpPost]
        public ActionResult<WineCooler> Post([FromBody] WineCooler newCooler) {
            if (newCooler.BottlesInStorage < 0 || newCooler.CapacityOfBottles <= 0){
                return BadRequest(newCooler);
            }

            manager.AddCooler(newCooler);
            



            return Created("api/winecoolers/" + newCooler.Id, newCooler);
        }


        // DELETE api/<WineCoolersController>/5
        [HttpDelete("{id}")]
        public ActionResult<WineCooler> Delete(int id){
            WineCooler result = manager.GetCooler(id);
            if (result == null){
                return NotFound(id);
            }

            return Ok(manager.DeleteCooler(id));
        }

        [HttpGet("{id}/Addwine")]
        public ActionResult<bool> AddWine([FromRoute] int id){
            var result = manager.GetCooler(id);
            if(result.CoolerIsFull()){
                return Conflict();
            }

            return Ok("Bottles now " + manager.AddWine(id));

        }

    }
}
