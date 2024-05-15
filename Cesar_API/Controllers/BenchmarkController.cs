using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using BLL.Models;

namespace Cesar_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BenchmarkController : ControllerBase
    {

        [HttpPost]
        [Route("Sum")]
        public async Task<ActionResult<List<BenchmarkResult>>> Sum([FromBody] BenchmarkFromAPIRequestModel brm)
        {            
            string cpuUrl = $"{brm.CpuRoute}/CesarConroller/SumCPU";
            string cpuMultiThredUrl = $"{brm.CpuRoute}/CesarConroller/SumCPUMultiThred";
            string gpuUrl = $"{brm.GpuRoute}/CesarConroller/SumGPU";

            Matrix array = new Matrix(brm.EndSize);
            array.RandFil();

            BenchmarkRequestModel requestData = new BenchmarkRequestModel()
            {
                Data = array.To2DList(),
                StartSize = brm.StartSize,
                EndSize = brm.EndSize,
                Step = brm.Step
            };
            string jsonData = JsonConvert.SerializeObject(requestData);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Створюємо клієнта HTTP
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30000);
               

                // Виконуємо POST-запит
                HttpResponseMessage responseCPU = await client.PostAsync(cpuUrl, content);
                HttpResponseMessage responseCPUMultiThred = await client.PostAsync(cpuMultiThredUrl, content);
                HttpResponseMessage responseGPU = await client.PostAsync(gpuUrl, content);

                // Перевіряємо результат
                if (responseCPU.IsSuccessStatusCode && responseCPUMultiThred.IsSuccessStatusCode && responseGPU.IsSuccessStatusCode)
                {
                    string responseDataCPU = await responseCPU.Content.ReadAsStringAsync();
                    string responseDataCPUMultiThred = await responseCPUMultiThred.Content.ReadAsStringAsync();
                    string responseDataGPU = await responseGPU.Content.ReadAsStringAsync();

                    List<SimpleResult> rpDataCPU = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataCPU);
                    List<SimpleResult> rpDataCPUMultiThred = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataCPUMultiThred);
                    List<SimpleResult> rpDataGPU = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataGPU);
                    List<BenchmarkResult> result = new List<BenchmarkResult>();
                    //Console.WriteLine(responseDataCPU);
                    /*foreach (SimpleResult r in rpDataCPU)
                    {
                        Console.WriteLine(r.Size);
                        Console.WriteLine(r.ElapsedTime);
                    }*/
                    for (int i = 0; i < rpDataCPU.Count; i++)
                    {
                        result.Add(new BenchmarkResult(rpDataCPU[i].Size, rpDataCPU[i].ElapsedTime, rpDataCPUMultiThred[i].ElapsedTime, rpDataGPU[i].ElapsedTime));
                    }
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        [Route("Mult")]
        public async Task<ActionResult<List<BenchmarkResult>>> Mult([FromBody] BenchmarkFromAPIRequestModel brm)
        {
            string cpuUrl = $"{brm.CpuRoute}/CesarConroller/MultCPU";
            string cpuMultiThredUrl = $"{brm.CpuRoute}/CesarConroller/MultCPUMultiThred";
            string gpuUrl = $"{brm.GpuRoute}/CesarConroller/MultGPU";

            Matrix array = new Matrix(brm.EndSize);
            array.RandFil();

            BenchmarkRequestModel requestData = new BenchmarkRequestModel()
            {
                Data = array.To2DList(),
                StartSize = brm.StartSize,
                EndSize = brm.EndSize,
                Step = brm.Step
            };
            string jsonData = JsonConvert.SerializeObject(requestData);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Створюємо клієнта HTTP
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30000);


                // Виконуємо POST-запит
                HttpResponseMessage responseCPU = await client.PostAsync(cpuUrl, content);
                HttpResponseMessage responseCPUMultiThred = await client.PostAsync(cpuMultiThredUrl, content);
                HttpResponseMessage responseGPU = await client.PostAsync(gpuUrl, content);

                // Перевіряємо результат
                if (responseCPU.IsSuccessStatusCode && responseCPUMultiThred.IsSuccessStatusCode && responseGPU.IsSuccessStatusCode)
                {
                    string responseDataCPU = await responseCPU.Content.ReadAsStringAsync();
                    string responseDataCPUMultiThred = await responseCPUMultiThred.Content.ReadAsStringAsync();
                    string responseDataGPU = await responseGPU.Content.ReadAsStringAsync();

                    List<SimpleResult> rpDataCPU = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataCPU);
                    List<SimpleResult> rpDataCPUMultiThred = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataCPUMultiThred);
                    List<SimpleResult> rpDataGPU = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataGPU);
                    List<BenchmarkResult> result = new List<BenchmarkResult>();
                    for (int i = 0; i < rpDataCPU.Count; i++)
                    {
                        result.Add(new BenchmarkResult(rpDataCPU[i].Size, rpDataCPU[i].ElapsedTime, rpDataCPUMultiThred[i].ElapsedTime, rpDataGPU[i].ElapsedTime));
                    }
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        [Route("Sing")]
        public async Task<ActionResult<List<BenchmarkResult>>> Sing([FromBody] BenchmarkFromAPIRequestModel brm)
        {
            string cpuUrl = $"{brm.CpuRoute}/CesarConroller/SingCPU";
            string cpuMultiThredUrl = $"{brm.CpuRoute}/CesarConroller/SingCPUMultiThred";
            string gpuUrl = $"{brm.GpuRoute}/CesarConroller/SingGPU";

            Matrix array = new Matrix(brm.EndSize);
            array.RandFil();

            BenchmarkRequestModel requestData = new BenchmarkRequestModel()
            {
                Data = array.To2DList(),
                StartSize = brm.StartSize,
                EndSize = brm.EndSize,
                Step = brm.Step
            };
            string jsonData = JsonConvert.SerializeObject(requestData);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Створюємо клієнта HTTP
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30000);


                // Виконуємо POST-запит
                HttpResponseMessage responseCPU = await client.PostAsync(cpuUrl, content);
                HttpResponseMessage responseCPUMultiThred = await client.PostAsync(cpuMultiThredUrl, content);
                HttpResponseMessage responseGPU = await client.PostAsync(gpuUrl, content);

                // Перевіряємо результат
                if (responseCPU.IsSuccessStatusCode && responseCPUMultiThred.IsSuccessStatusCode && responseGPU.IsSuccessStatusCode)
                {
                    string responseDataCPU = await responseCPU.Content.ReadAsStringAsync();
                    string responseDataCPUMultiThred = await responseCPUMultiThred.Content.ReadAsStringAsync();
                    string responseDataGPU = await responseGPU.Content.ReadAsStringAsync();

                    List<SimpleResult> rpDataCPU = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataCPU);
                    List<SimpleResult> rpDataCPUMultiThred = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataCPUMultiThred);
                    List<SimpleResult> rpDataGPU = JsonConvert.DeserializeObject<List<SimpleResult>>(responseDataGPU);
                    List<BenchmarkResult> result = new List<BenchmarkResult>();
                    for (int i = 0; i < rpDataCPU.Count; i++)
                    {
                        result.Add(new BenchmarkResult(rpDataCPU[i].Size, rpDataCPU[i].ElapsedTime, rpDataCPUMultiThred[i].ElapsedTime, rpDataGPU[i].ElapsedTime));
                    }
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}
