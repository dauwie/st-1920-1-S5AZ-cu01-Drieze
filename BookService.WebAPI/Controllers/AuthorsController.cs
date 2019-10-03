﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookService.WebAPI.Repositories;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorRepository repository;

        public AuthorsController(AuthorRepository authorRepository)
        {
            repository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(repository.ListAll());
        }

        // GET: api/Authors/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetAuthorsBasic()
        {
            return Ok(await repository.ListBasic());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAuthor(int id)
        {
            return Ok(repository.GetById(id));
        }
    }
}