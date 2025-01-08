using question2.Entities;


namespace School_API.Repositories
{
    public class IUnitOfWorkSchoolSQL : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;

        private BaseRepositorySQL<Student> _studentRepository;


        public IUnitOfWorkSchoolSQL(SchoolContext context)
        {

            this._context = context;
            this._studentRepository = new BaseRepositorySQL<Student>(context);

        }

        public IRepository<Student> StudentRepository
        {
            get { return this._studentRepository; }
        }
    }
}

