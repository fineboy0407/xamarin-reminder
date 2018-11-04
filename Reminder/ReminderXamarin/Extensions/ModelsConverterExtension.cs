using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReminderXamarin.Helpers;
using ReminderXamarin.Models;
using ReminderXamarin.ViewModels;
using Xamarin.Forms;

namespace ReminderXamarin.Extensions
{
    public static class ModelsConverterExtension
    {
        public static PhotoViewModel ToPhotoViewModel(this PhotoModel model)
        {
            var viewModel = new PhotoViewModel
            {
                Id = model.Id,
                NoteId = model.NoteId,
                Landscape = model.Landscape,
                ResizedPath = model.ResizedPath,
                Thumbnail = model.Thumbnail
            };
            return viewModel;
        }

        public static PhotoModel ToPhotoModel(this PhotoViewModel viewModel)
        {
            var model = new PhotoModel
            {
                Id = viewModel.Id,
                NoteId = viewModel.NoteId,
                Landscape = viewModel.Landscape,
                ResizedPath = viewModel.ResizedPath,
                Thumbnail = viewModel.Thumbnail
            };
            return model;
        }

        public static ObservableCollection<PhotoViewModel> ToPhotoViewModels(this IEnumerable<PhotoModel> models)
        {
            return models.Select(model => new PhotoViewModel
                {
                    Id = model.Id,
                    Landscape = model.Landscape,
                    ResizedPath = model.ResizedPath,
                    Thumbnail = model.Thumbnail,
                    NoteId = model.NoteId
                }).ToObservableCollection();
        }

        public static IEnumerable<PhotoModel> ToPhotoModels(this IEnumerable<PhotoViewModel> viewModels)
        {
            return viewModels.Select(viewModel => new PhotoModel
            {
                Id = viewModel.Id,
                Landscape = viewModel.Landscape,
                ResizedPath = viewModel.ResizedPath,
                Thumbnail = viewModel.Thumbnail,
                NoteId = viewModel.NoteId
            });
        }

        public static NoteViewModel ToNoteViewModel(this Note note)
        {
            var viewModel = new NoteViewModel
            {
                Id = note.Id,
                CreationDate = note.CreationDate,
                EditDate = note.EditDate,
                Description = note.Description,
                FullDescription = note.EditDate.ToString("dd.MM.yy") + " "+ note.Description,
                Photos = note.Photos.ToPhotoViewModels()
            };
            return viewModel;
        }

        public static Note ToNoteModel(this NoteViewModel note)
        {
            var model = new Note
            {
                Id = note.Id,
                UserId = Settings.CurrentUserId,
                CreationDate = note.CreationDate,
                EditDate = note.EditDate,
                Description = note.Description,
                Photos = note.Photos.ToPhotoModels().ToList()
            };
            return model;
        }

        public static IEnumerable<NoteViewModel> ToNoteViewModels(this IEnumerable<Note> models)
        {
            return models.Select(model => new NoteViewModel
                {
                    Id = model.Id,
                    CreationDate = model.CreationDate,
                    EditDate = model.EditDate,
                    Description = model.Description,
                    FullDescription = model.EditDate.ToString("dd.MM.yy") + " " + model.Description,
                    Photos = model.Photos.ToPhotoViewModels()
                })
                .ToList();
        }

        public static IEnumerable<Note> ToNoteViewModels(this IEnumerable<NoteViewModel> viewModels)
        {
            return viewModels.Select(viewModel => new Note
                {
                    Id = viewModel.Id,
                    CreationDate = viewModel.CreationDate,
                    EditDate = viewModel.EditDate,
                    Description = viewModel.Description,
                    Photos = viewModel.Photos.ToPhotoModels().ToList()
                })
                .ToList();
        }

        public static ToDoModel ToToDoModel(this ToDoViewModel viewModel)
        {
            return new ToDoModel
            {
                Id = viewModel.Id,
                UserId = Settings.CurrentUserId,
                Priority = viewModel.Priority.ToString(),
                WhenHappens = viewModel.WhenHappens,
                Description = viewModel.Description
            };
        }

        public static ToDoViewModel ToToDoViewModel(this ToDoModel model)
        {
            var viewModel = new ToDoViewModel
            {
                Id = model.Id,
                WhenHappens = model.WhenHappens,
                Description = model.Description
            };

            switch (model.Priority)
            {
                case ConstantsHelper.High:
                    viewModel.Priority = ToDoPriority.High;
                    break;
                case ConstantsHelper.Medium:
                    viewModel.Priority = ToDoPriority.Medium;
                    break;
                default:
                    viewModel.Priority = ToDoPriority.Low;
                    break;
            }
            return viewModel;
        }

        public static IEnumerable<ToDoModel> ToToDoModels(this IEnumerable<ToDoViewModel> viewModels)
        {
            return viewModels.Select(viewModel => new ToDoModel
            {
                Id = viewModel.Id,
                Priority = viewModel.Priority.ToString(),
                WhenHappens = viewModel.WhenHappens,
                Description = viewModel.Description
            })
            .ToList();
        }

        public static IEnumerable<ToDoViewModel> ToToDoViewModels(this IEnumerable<ToDoModel> models)
        {
            var viewModels = new List<ToDoViewModel>();

            foreach (var model in models)
            {
                var viewModel = new ToDoViewModel
                {
                    Id = model.Id,
                    WhenHappens = model.WhenHappens,
                    Description = model.Description
                };
                switch (model.Priority)
                {
                    case ConstantsHelper.High:
                        viewModel.Priority = ToDoPriority.High;
                        break;
                    case ConstantsHelper.Medium:
                        viewModel.Priority = ToDoPriority.Medium;
                        break;
                    default:
                        viewModel.Priority = ToDoPriority.Low;
                        break;
                }
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public static BirthdayModel ToBirthdayModel(this BirthdayViewModel viewModel)
        {
            return new BirthdayModel
            {
                Id = viewModel.Id,
                UserId = Settings.CurrentUserId,
                Name = viewModel.Name,
                ImageContent = viewModel.ImageContent,
                BirthDayDate = viewModel.BirthDayDate,
                GiftDescription = viewModel.GiftDescription
            };
        }

        public static BirthdayViewModel ToBirthdayViewModel(this BirthdayModel model)
        {
            return new BirthdayViewModel
            {
                Id = model.Id,
                Name = model.Name,
                ImageContent = model.ImageContent,
                BirthDayDate = model.BirthDayDate,
                GiftDescription = model.GiftDescription
            };
        }

        public static IEnumerable<BirthdayModel> ToBirthdayModels(this IEnumerable<BirthdayViewModel> viewModels)
        {
            return viewModels.Select(viewModel => viewModel.ToBirthdayModel()).ToObservableCollection();
        }

        public static IEnumerable<BirthdayViewModel> ToFriendViewModels(this IEnumerable<BirthdayModel> models)
        {
            return models.Select(model => model.ToBirthdayViewModel()).ToObservableCollection();
        }

        public static IEnumerable<Image> ToImages(this IEnumerable<PhotoViewModel> viewModels)
        {
            var images = new ObservableCollection<Image>();
            foreach (var viewModel in viewModels)
            {
                images.Add(viewModel.ToImage());
            }
            return images;
        }

        public static Image ToImage(this PhotoViewModel viewModel)
        {
            return new Image { Source = viewModel.ResizedPath };
        }

        public static AchievementNote ToAchievementNote(this AchievementNoteViewModel viewModel)
        {
            return new AchievementNote
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                Date = viewModel.Date,
                HoursSpent = viewModel.HoursSpent,
                AchievementId = viewModel.AchievementId
            };
        }

        public static AchievementNoteViewModel ToAchievementNoteViewModel(this AchievementNote model)
        {
            return new AchievementNoteViewModel
            {
                Id = model.Id,
                Description = model.Description,
                Date = model.Date,
                HoursSpent = model.HoursSpent,
                AchievementId = model.AchievementId
            };
        }

        public static ObservableCollection<AchievementNoteViewModel> ToAchievementNoteViewModels(
            this IEnumerable<AchievementNote> models)
        {
            return models.Select(model => model.ToAchievementNoteViewModel()).ToObservableCollection();
        }

        public static IEnumerable<AchievementNote> ToAchievementNoteViewModels(
            this IEnumerable<AchievementNoteViewModel> viewModels)
        {
            return viewModels.Select(viewModel => viewModel.ToAchievementNote()).ToList();
        }

        public static AchievementModel ToAchievementModel(this AchievementViewModel viewModel)
        {
            return new AchievementModel
            {
                Id = viewModel.Id,
                UserId = Settings.CurrentUserId,
                AchievementNotes = viewModel.AchievementNotes.ToAchievementNoteViewModels().ToList(),
                Title = viewModel.Title,
                GeneralDescription = viewModel.GeneralDescription,
                GeneralTimeSpent = viewModel.GeneralTimeSpent,
                ImageContent = viewModel.ImageContent
            };
        }

        public static AchievementViewModel ToAchievementViewModel(this AchievementModel model)
        {
            return new AchievementViewModel
            {
                Id = model.Id,
                AchievementNotes = model.AchievementNotes.ToAchievementNoteViewModels(),
                Title = model.Title,
                GeneralDescription = model.GeneralDescription,
                GeneralTimeSpent = model.GeneralTimeSpent,
                ImageContent = model.ImageContent
            };
        }

        public static IEnumerable<AchievementModel> ToAchievementModels(
            this IEnumerable<AchievementViewModel> viewModels)
        {
            return viewModels.Select(viewModel => viewModel.ToAchievementModel()).ToList();
        }

        public static IEnumerable<AchievementViewModel> ToAchievementViewModels(
            this IEnumerable<AchievementModel> models)
        {
            return models.Select(model => model.ToAchievementViewModel()).ToList();
        }

        public static UserModel ToUserModel(this UserProfileViewModel viewModel)
        {
            return new UserModel
            {
                Id = viewModel.Id,
                ImageContent = viewModel.ImageContent,
                UserName = viewModel.UserName
            };
        }

        public static UserProfileViewModel ToUserProfileViewModel(this UserModel model)
        {
            return new UserProfileViewModel
            {
                Id = model.Id,
                ImageContent = model.ImageContent,
                UserName = model.UserName,
                NotesCount = model.Notes.Count,
                AchievementsCount = model.Achievements.Count,
                FriendBirthdaysCount = model.Birthdays.Count
            };
        }
    }
}