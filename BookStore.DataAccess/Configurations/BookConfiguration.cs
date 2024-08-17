using BookStore.Core.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.BookId);
        builder.Property(x => x.Title)
                                .IsRequired()
                                .HasMaxLength(250);//TODO Указать ссылку на MAX_TITLE_LENGHT
    }
}