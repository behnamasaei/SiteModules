using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using BlogApi.Infrastructure.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BlogDbContext _context;
    private readonly ILogger _logger;

    public IPostRepository Post { get; private set; }
    public ICategoryRepository Category { get; private set; }
    public ITagRepository Tag { get; private set; }


    public UnitOfWork(BlogDbContext context , ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");

        Post = new PostRepository(context, _logger);
        Tag = new TagRepository(context, _logger);
        Category = new CategoryRepository(context, _logger);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

