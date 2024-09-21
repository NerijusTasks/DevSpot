using DevSpot.Data;
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
                Title = "Test Title Adding",
                Description = "Test Description",
                PostedDate = DateTime.Now,
                Company = "Test Compaby",
                Location = "Test Location",
                UserId = "TestUserId"
            };

            // execute

            await repository.AddAsync(jobPosting);

            // result

            var result = db.JobPosts.Find(jobPosting.Id);

            // assert

            Assert.NotNull(result);
            Assert.Equal("Test Title Adding", result.Title);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnJobPosting()
        {
            var db = CreateDbContext();

            var repository = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Title",
                Description = "Test Description",
                PostedDate = DateTime.Now,
                Company = "Test Compaby",
                Location = "Test Location",
                UserId = "TestUserId"
            };

            db.JobPosts.AddAsync(jobPosting);
            await db.SaveChangesAsync();

            var result = await repository.GetByIdAsinc(jobPosting.Id);

            Assert.NotNull(result);
            Assert.Equal("Test Title", result.Title);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundException()
        {
            var db = CreateDbContext();
            var repository = new JobPostingRepository(db);

            Assert.ThrowsAsync<KeyNotFoundException>(
                () => repository.GetByIdAsinc(999)
            );
        }

        [Fact]
        public async Task GetTaskAsync_ShouldReturnAllJobPostings()
        {
            var db = CreateDbContext();

            var repository = new JobPostingRepository(db);

            var jobPosting1 = new JobPosting
            {
                Title = "Test Title 1",
                Description = "Test Description 1",
                PostedDate = DateTime.Now,
                Company = "Test Compaby 1",
                Location = "Test Location 1",
                UserId = "TestUserId 1"
            };

            var jobPosting2 = new JobPosting
            {
                Title = "Test Title 2",
                Description = "Test Description 2",
                PostedDate = DateTime.Now,
                Company = "Test Compaby 2",
                Location = "Test Location 2",
                UserId = "TestUserId 2"
            };

            db.JobPosts.AddRangeAsync(jobPosting1, jobPosting2);
            await db.SaveChangesAsync();

            var result = await repository.GetAllAsync();

            Assert.NotNull( result );
            Assert.True(result.Count() >=2);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateJobPosting()
        {
            var db = CreateDbContext();
            var repository = new JobPostingRepository(db);

            var jobPosting = new JobPosting
            {
                Title = "Test Title 2",
                Description = "Test Description 2",
                PostedDate = DateTime.Now,
                Company = "Test Compaby 2",
                Location = "Test Location 2",
                UserId = "TestUserId 2"
            };

            await db.JobPosts.AddAsync(jobPosting);
            await db.SaveChangesAsync();

            jobPosting.Description = "Updated Description";

            await repository.Updateasync(jobPosting);
            var result = db.JobPosts.Find(jobPosting.Id);

            Assert.NotNull( result );
            Assert.Equal("Updated Description", result.Description);
        }
    }
}
