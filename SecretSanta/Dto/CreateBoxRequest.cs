using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SecretSanta.Application.Validation;

namespace SecretSanta.Dto
{
    public class CreateBoxRequest
    {
        /// <summary>
        /// Наименование коробки
        /// </summary>
        [DefaultValue("The box")]
        [Required(ErrorMessage = "Наименование обязательно для заполнения.")]
        [Display(Name = "Наименование коробки")]
        public string Name { get; set; }
        
        /// <summary>
        /// Описание коробки
        /// </summary>
        [MaxLength(500, ErrorMessage = "Описание не может превышать 500 символов.")]
        [Display(Name = "Описание коробки")]
        public string Description { get; set; }

        /// <summary>
        /// Иконка коробки
        /// </summary>
        [Url(ErrorMessage = "Неверный формат URL для иконки.")]
        [Display(Name = "Иконка")]
        public string Icon { get; set; }

        /// <summary>
        /// Дата начала приема участников
        /// </summary>
        [Required(ErrorMessage = "Дата начала приема участников обязательна.")]
        [Display(Name = "Дата начала приема участников")]
        public DateTime ParticipantsStartDate { get; set; }

        /// <summary>
        /// Дата окончания приема участников
        /// </summary>
        [Required(ErrorMessage = "Дата окончания приема участников обязательна.")]
        [Display(Name = "Дата окончания приема участников")]
        public DateTime ParticipantsEndDate { get; set; }

        /// <summary>
        /// Дата начала покупки подарков
        /// </summary>
        [Required(ErrorMessage = "Дата начала покупки подарков обязательна.")]
        [Display(Name = "Дата начала покупки подарков")]
        public DateTime GiftPurchaseStartDate { get; set; }

        /// <summary>
        /// Дата окончания покупки подарков
        /// </summary>
        [Required(ErrorMessage = "Дата окончания покупки подарков обязательна.")]
        [Display(Name = "Дата окончания покупки подарков")]
        public DateTime GiftPurchaseEndDate { get; set; }

        /// <summary>
        /// Дата окончания обсуждения коробки
        /// </summary>
        [Required(ErrorMessage = "Дата окончания обсуждения обязательна.")]
        [Display(Name = "Дата окончания обсуждения")]
        public DateTime DiscussionEndDate { get; set; }

        /// <summary>
        /// Сумма подарков от
        /// </summary>
        [Required(ErrorMessage = "Минимальная сумма подарка обязательна.")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма подарка должна быть больше или равна нулю.")]
        [Display(Name = "Сумма подарков от")]
        public decimal MinGiftAmount { get; set; }

        /// <summary>
        /// Сумма подарков до
        /// </summary>
        [Required(ErrorMessage = "Максимальная сумма подарка обязательна.")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма подарка должна быть больше или равна нулю.")]
        [GreaterThanValidation("MinGiftAmount", ErrorMessage = "Сумма подарка до должна быть больше суммы подарка от.")]
        [Display(Name = "Сумма подарков до")]
        public decimal MaxGiftAmount { get; set; }

        /// <summary>
        /// Место проведения
        /// </summary>
        [MaxLength(255, ErrorMessage = "Место проведения не может превышать 255 символов.")]
        [Display(Name = "Место проведения")]
        public string Location { get; set; }
    }
}
