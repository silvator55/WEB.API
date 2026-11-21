
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishersAsync()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<Publisher?> GetPublisherByIdAsync(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            await _publisherRepository.AddAsync(publisher);
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            var existingPublisher = await _publisherRepository.GetByIdAsync(publisher.Id);

            if (existingPublisher == null)
                throw new Exception("Publisher not found");

            _publisherRepository.Update(publisher);
        }

        public async Task DeletePublisherAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);

            if (publisher == null)
                throw new Exception("Publisher not found");

            _publisherRepository.Delete(publisher);
        }

        public async Task<IEnumerable<Publisher>> SearchPublishersAsync(string searchTerm)
        {
            return await _publisherRepository.SearchAsync(searchTerm);
        }

        public async Task<bool> PublisherExistsAsync(int id)
        {
            return await _publisherRepository.ExistsAsync(id);
        }
    }
}
