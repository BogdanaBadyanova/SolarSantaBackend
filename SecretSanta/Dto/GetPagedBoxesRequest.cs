using System.ComponentModel;

namespace SecretSanta.Dto
{
  public class GetPagedBoxesRequest : IPagedRequest
  {
    /// <summary>
    /// Наименование коробки
    /// </summary>
    [DefaultValue(null)]
    public string? Name { get; set; }

    /// <summary>
    /// Номер страницы для пагинации
    /// </summary>
    [DefaultValue(1)]
    public required int Page { get; set; } = 1;

    /// <summary>
    /// Размер страницы для пагинации
    /// </summary>
    [DefaultValue(10)]
    public required int Size { get; set; } = 10;
  }
}
