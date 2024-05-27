using System;
using Microsoft.AspNetCore.Mvc;
using MagicVilla.model;
using System.Collections.Generic;
using MagicVilla.model.dto;
using MagicVilla.Data;

namespace MagicVilla.Controllers
{
    [Route("/api/getVilla")]
    [ApiController]

    public class FakeDataController : ControllerBase
    {
        [HttpGet]

        public ActionResult<IEnumerable<VillaDto>> GetData()
        {
            return VillaData.VillaList;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be 0");
            }
            VillaDto data = VillaData.VillaList.FirstOrDefault(data => data.id == id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("id is not available");
            }

        }

        [HttpPost]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villadata)
        {
            if (villadata == null)
            {
                return BadRequest();
            }
            if (villadata.id > 0)
            {
                return BadRequest("Id should be 0");
            }
            else
            {
                villadata.id = VillaData.VillaList.OrderByDescending(villa => villa.id).FirstOrDefault().id + 1;
                VillaData.VillaList.Add(villadata);

                return Ok(villadata);
            }
        }

        [HttpDelete("{id:int}" , Name ="DeleteData")]

        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            VillaDto villa = VillaData.VillaList.FirstOrDefault((x) => x.id == id);
            if(villa == null)
            {
                return BadRequest("Data Not Found with the above id");
            }
            else
            {
                VillaData.VillaList.Remove(villa);
                return NoContent();
            }
        }
    }
}
