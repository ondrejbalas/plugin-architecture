using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaSoft.Data;
using PizzaSoft.Domain;
using PizzaSoft.Domain.Abstract;
using PizzaSoft.Models;
using PizzaSoft.Plugins;

namespace PizzaSoft.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaCreationProcess creationProcess;
        private readonly IStateRepository stateRepository;

        public PizzaController(IPizzaCreationProcess creationProcess, IStateRepository stateRepository)
        {
            this.creationProcess = creationProcess;
            this.stateRepository = stateRepository;
        }

        public ActionResult Index(string id = null)
        {
            // Attempt to load the state associated with the id
            var currentState = stateRepository.Load(id);

            // If the state doesn't exist, create a new state object and save it
            if (currentState == null)
            {
                currentState = new PizzaState() { Id = Guid.NewGuid().ToString() };
                stateRepository.Save(currentState);
            }

            // Build the view model based on the state object and return the view
            return View(BuildViewModel(currentState));
        }

        [HttpPost]
        public ActionResult Index(string stateId, string currentStepName, string[] selectedOptions)
        {
            // PRG (Post-Redirect-Get) pattern: make changes on the POST and then redirect to a GET
            // Load the state object
            var priorState = stateRepository.Load(stateId);

            // Check that it was loaded
            if (priorState != null)
            {
                // Check if the current step already exists in the state object. If it does, remove it
                if (priorState.StepResults.Any(x => x.StepName == currentStepName))
                {
                    priorState.StepResults.Remove(priorState.StepResults.Single(x => x.StepName == currentStepName));
                }

                // Add the current step's data to the state object
                var newStepResult = new PizzaStepResult() {StepName = currentStepName};
                if (selectedOptions != null)
                {
                    newStepResult.SelectedOptions.AddRange(selectedOptions);
                }
                priorState.StepResults.Add(newStepResult);

                // Save the state object
                stateRepository.Save(priorState);

            }
            // Redirect back to the GET, passing the id of the current state
            return RedirectToAction("Index", new { id = stateId });
        }

        /// <summary>
        /// Examines the current state object and uses it to build the view model
        /// </summary>
        /// <param name="currentState"></param>
        /// <returns></returns>
        private PizzaCreationViewModel BuildViewModel(PizzaState currentState)
        {
            IPizzaCreationStep currentStep = null;
            var viewModel = new PizzaCreationViewModel();

            // Iterate through all steps in the creation process
            foreach (var step in creationProcess.GetStepsInProcess())
            {
                // If the state object contains data for the current step, test for validation 
                var stateForCurrentStep = currentState.StepResults.SingleOrDefault(x => x.StepName == step.StepName);
                if(stateForCurrentStep != null)
                {
                    // test for validation
                    var validationResult = step.Validate(stateForCurrentStep);
                    if (!validationResult)
                    {
                        // If validation fails, this is the current step.
                        currentStep = step;
                        // Add the validation message to the view model
                        viewModel.ShowValidationMessage = true;
                        viewModel.ValidationMessage = currentStep.ValidationErrorMessage(stateForCurrentStep);
                        break;
                    }
                    else
                    {
                        // If validation passes, move on to the next step.
                        continue;
                    }
                }
                else
                {
                    // If the state object does not contain this step, it is the current step
                    currentStep = step;
                    break;
                }
            }

            // If the user has continued past the last step, throw an exception. This could be handled better.
            if (currentStep == null)
            {
                throw new ApplicationException("Continued past last step. Last step should not have any options.");
            }
                
            // Build the view model using the current step object of our current state.
            viewModel.CanSelectMultiple = currentStep.CanSelectMultiple;
            viewModel.CurrentStateId = currentState.Id;
            viewModel.CurrentStepName = currentStep.StepName;
            viewModel.DetailsHtml = currentStep.GetDetailsHtml(currentState);
            viewModel.HeaderText = currentStep.StepHeaderText;
            viewModel.Options = currentStep.Options;

            // Return the view model
            return viewModel;
        }
    }
}
