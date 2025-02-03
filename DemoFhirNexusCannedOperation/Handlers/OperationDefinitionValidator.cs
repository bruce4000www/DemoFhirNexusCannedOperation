using Hl7.Fhir.Model;
using Ihis.FhirEngine.Core;
using Task = System.Threading.Tasks.Task;

namespace DemoFhirNexusCannedOperation.Handlers
{
    [FhirHandlerClass(AcceptedType = nameof(OperationDefinition))]
    public class OperationDefinitionValidator
    {
        [FhirHandler(HandlerCategory.PreCRUD, FhirInteractionType.Create)]
        public async Task PreCRUD(IFhirContext fhirContext, CancellationToken cancellationToken = default)
        {
            fhirContext.Response.SetIsHandled(true);
            fhirContext.Response.SetResourceResponse(new OperationOutcome
            {
                Issue = new List<OperationOutcome.IssueComponent>
                {
                    new OperationOutcome.IssueComponent
                    {
                        Severity = OperationOutcome.IssueSeverity.Information,
                        Code = OperationOutcome.IssueType.Informational,
                        Details = new CodeableConcept
                        {
                            Text = "All OK"
                        }
                    }
                }
            });
        }
    }
}
