﻿using DevSpot.Data;
using DevSpot.Models;
using DevSpot.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSpot.Tests
{
    public class JobPostingRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public JobPostingRepositoryTests()
        { 
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("JobPostingDb")
                .Options;
        }

        private ApplicationDbContext CreateDbContext() => new ApplicationDbContext(_options);


        [Fact]
        public async Task AddAsync_ShouldAddJobPosting()
        {
            // db context
            var db = CreateDbContext();

            // job posting repository

            var repository = new JobPostingRepository(db);

            // job posting

            var jobPosting = new JobPosting
            {
                Title = "Test Title",
                Description = "Test Description",
                PostedDate = DateTime.Now,
                Company = "Test Compaby",
                Location = "Test Location",
                UserId = "TestUserId"
            };

            // execute

            await repository.AddAsync(jobPosting);

            // result

            var result = db.JobPosts.SingleOrDefault(x => x.Title == "Test Title");

            // assert

            Assert.NotNull(result);
            Assert.Equal("Test Description", result.Description);
        }
    }
}
