using SecretSanta.Domain;

namespace SecretSanta.Dto
{
  public class BoxView
  {
    // Уникальный идентификатор
    public Guid Id { get; set; }

    // Уникальный идентификатор в формате HC46FV74FH
    public string IdCode { get; }

    // Название коробки
    public string Name { get; set; }

    // Описание коробки
    public string Description { get; set; }

    // Иконка коробки (например, URL или путь к изображению)
    public string Icon { get; set; }

    // Дата начала приема участников
    public DateTime StartDate { get; set; }

    // Дата окончания приема участников
    public DateTime EndDate { get; set; }

    // Дата распределения (рандомизация) участников
    public DateTime RandomizationDate { get; set; }

    // Дата окончания покупки подарков
    public DateTime GiftPurchaseEndDate { get; set; }

    // Сумма подарков от и до
    public decimal MinGiftValue { get; set; }
    public decimal MaxGiftValue { get; set; }

    // Место проведения
    public string Location { get; set; }
  }
}
