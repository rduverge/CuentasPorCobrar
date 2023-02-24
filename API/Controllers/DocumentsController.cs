using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using CuentasPorCobrar.Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentRepository repo; 

    //constructor injects repository registered in Program 

    public DocumentsController(IDocumentRepository repo)
    {
        this.repo=repo; 
    }


    [HttpGet]
    [ProducesResponseType(200, Type=typeof(IEnumerable<Document>))]
    public async Task<IEnumerable<Document>> GetDocuments()
    {
        return await repo.RetrieveAllAsync(); 
    }



    //GET: api/documents[id]
    [HttpGet("{id}", Name =nameof(GetDocument))] //named route
    [ProducesResponseType(200,Type=typeof(Document))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetDocument(int id)
    {
        Document? document = await repo.RetrieveAsync(id);

        
        return document is null ? NotFound() : Ok(document); 
    }

    //POST: api/documents
    //Body: Document(JSON,XML)
    [HttpPost]
    [ProducesResponseType(201, Type= typeof(Document))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Document document)
    {
        if (document is null) return BadRequest(); //400

        Document? addedDoument = await repo.CreateAsync(document);

        return addedDoument is null ? BadRequest("Repository failed to create Document.")
            :CreatedAtRoute(routeName:nameof(GetDocument), 
            routeValues: new {id= addedDoument.DocumentId},
            value:addedDoument); 
    }

    //PUT: api/documents/[id]
    //BODY: Document (JSON,XML)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] Document document)
    {
        if(document is null || document.DocumentId !=id) return BadRequest();



        Document? existing = await repo.RetrieveAsync(id);

        if (existing is null) return NotFound();
        await repo.UpdateAsync(id, document);

        return new NoContentResult(); // 204 No content
    }
    //DELETE: api/documents/[id]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        Document? existing = await repo.RetrieveAsync(id);
        if (existing is null) return NotFound(); //404 Resource Not Found

        bool? deleted = await repo.DeleteAsync(id);

        //sHORT CIRCUIT AND 
        return deleted.HasValue && deleted.Value ?
             new NoContentResult() 
             : BadRequest($"Document {id} was found but failed to delete"); 

    }


}

