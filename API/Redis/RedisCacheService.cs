using Business.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Redis
{
    public class RedisCacheService : ICacheService
    {
        private RedisServer _redisServer;
        private IEmployeeService _employeeService;

        public RedisCacheService(RedisServer redisServer, IEmployeeService employeeService)
        {
            _redisServer = redisServer;
            _employeeService = employeeService;
        }

        public void Add(string key, object data)
        {
            //string jsonData = JsonConvert.SerializeObject(data);
            string jsonData = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
            _redisServer.Database.StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);

        }

        public void CacheUpdate()
        {
            //_redisServer.FlushDatabase();
            
            var employees = _employeeService.GetAll();
            Add("employees", employees);
        }
    }
}
