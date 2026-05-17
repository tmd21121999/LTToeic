using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories;

public class ScoreConversionRepository : IScoreConversionRepository
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public ScoreConversionRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<int> GetListeningScoreAsync(int correctCount)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var entry = await ctx.ListeningScoreConversions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Correct == correctCount);
        return entry?.Score ?? Fallback(correctCount);
    }

    public async Task<int> GetReadingScoreAsync(int correctCount)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var entry = await ctx.ReadingScoreConversions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Correct == correctCount);
        return entry?.Score ?? Fallback(correctCount);
    }

    private static int Fallback(int correct) => Math.Min(correct * 5, 495);
}
