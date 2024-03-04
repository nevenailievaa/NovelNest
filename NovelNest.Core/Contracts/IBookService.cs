﻿namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.ViewModels.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> AllAsync();
        Task<IEnumerable<GenreViewModel>> AllGenresAsync();
        Task<IEnumerable<CoverTypeViewModel>> AllCoverTypesAsync();
    }
}