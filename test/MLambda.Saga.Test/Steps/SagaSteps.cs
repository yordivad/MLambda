using MLambda.Saga.Abstraction;
using TechTalk.SpecFlow;

namespace MLambda.Saga.Test.Steps
{
   [Binding]
    public class SagaSteps
    {
        [Given(@"a test")]
        public void GivenATest()
        {
            ISaga saga = new Saga();
        }
    }
}