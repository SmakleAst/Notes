using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
