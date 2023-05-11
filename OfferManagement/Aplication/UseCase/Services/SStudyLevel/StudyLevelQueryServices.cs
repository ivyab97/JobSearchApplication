using Aplication.DTO.Response;
using Aplication.Interfaces.IStudyLevel;

namespace Aplication.UseCase.Services.SStudyLevel
{
    public class StudyLevelQueryServices : IStudyLevelQueryServices
    {
        private readonly IStudyLevelQuery _query;

        public StudyLevelQueryServices(IStudyLevelQuery query)
        {
            _query = query;
        }

        public async Task<IList<StudyLevelResponse>> GetStudyLevels()
        {
            var levels = await _query.GetStudyLevelList();
            var response = new List<StudyLevelResponse>();

            foreach (var item in levels)
            {
                response.Add(new StudyLevelResponse
                {
                    Id = item.StudyLevelId,
                    Name = item.Name
                });
            }
            return response;
        }

        public async Task<StudyLevelResponse> GetStudyLevelById(int id)
        {
            var response = await _query.GetStudyLevel(id);

            if (response == null)
            {
                return null;
            }
            return new StudyLevelResponse
            {
                Id = response.StudyLevelId,
                Name = response.Name
            };
        }

        public async Task<bool> StudyLevelExists(int id)
        {
            if (await _query.GetStudyLevel(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
