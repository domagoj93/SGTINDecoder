using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGTINDecoder.Models;

namespace SGTINDecoder.API.Controllers
{
    [Route("api/SGTIN")]
    public class SGTINController : Controller
    {
        public string Get()
        {
            return "Welcome to SGTIN-96 decoder";
        }
        
        // GET api/SGTIN/3098D0A357783C0034E9DF74
        [HttpGet("{id}")]
        public SGTIN_96 Get(string id)
        {
            return Decoder.Decode_SGTIN_96(id);
        }
    }
}