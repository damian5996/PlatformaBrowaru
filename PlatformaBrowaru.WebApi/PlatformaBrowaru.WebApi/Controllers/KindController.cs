﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatformaBrowaru.Services.Services.Interfaces;
using PlatformaBrowaru.Share.BindingModels;
using PlatformaBrowaru.Share.ModelsDto;

namespace PlatformaBrowaru.WebApi.Controllers
{
    [Route("Kind")]
    public class KindController : BaseController
    {
        private readonly IKindService _kindService;

        public KindController(IKindService kindService)
        {
            _kindService = kindService;
        }

        [HttpGet]
        public IActionResult Search(SearchBindingModel parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelStateErrors());
            }

            var result = _kindService.GetKinds(parameters);

            if (result.ErrorOccured)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}