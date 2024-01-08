using System;
using System.Collections.Generic;

namespace RedGolemServer.Framework.Primitives
{
    public class PlayerConnectDeferral
    {
        private readonly dynamic _deferrals;

        public PlayerConnectDeferral(ref dynamic deferrals)
        {
            _deferrals = deferrals;
        }

        /// <summary>
        /// Will initialize deferrals for the current resource.
        /// <para>
        /// It is required to wait for at least a tick after calling <see cref="Defer"/> 
        /// before calling:
        /// <list type="bullet">
        /// <item><see cref="Update(string)"/></item>
        /// <item><see cref="PresentCard(string, Action{PresentCardCallbackParameter})"/></item>
        /// <item><see cref="Done"/></item>
        /// <item><see cref="DoneWithFail(string)"/></item>
        /// </list>
        /// </para>
        /// </summary>
        public void Defer()
        {
            _deferrals.defer();
        }

        /// <summary>
        /// Finalizes a deferral. It is required to wait for at least a tick before calling done after calling a prior deferral method.
        /// </summary>
        public void Done()
        {
            _deferrals.done();
        }

        /// <summary>
        /// Finalizes a deferral with fail. It is required to wait for at least a tick before calling done after calling a prior deferral method.
        /// </summary>
        /// <param name="failureReason">
        /// If specified, the connection will be refused, and the user will see the specified message as a result. 
        /// If this is not specified, the user will be allowed to connect.
        /// </param>
        public void DoneWithFail(string failureReason)
        {
            if (string.IsNullOrWhiteSpace(failureReason))
            {
                Done();
                return;
            }

            _deferrals.done(failureReason);
        }

        /// <summary>
        /// Adds handover data for the client to be able to use at a later point.
        /// </summary>
        /// <param name="data">Data to pass to the connecting client.</param>
        public void Handover(Dictionary<string, object> data)
        {
            _deferrals.handover(data);
        }

        /// <summary>
        /// Will send an Adaptive Card to the client.
        /// </summary>
        /// <param name="cardJson">a serialized JSON string with the card information</param>
        /// <param name="callback">If present, will be invoked on an Action.Submit event from the Adaptive Card.</param>
        public void PresentCard(string cardJson, Action<PresentCardCallbackParameter> callback = null)
        {
            if (cardJson == null)
                _deferrals.presentCard(cardJson);
            else
                _deferrals.presentCard(cardJson, new Action<object, string>((data, rawData) =>
                {
                    callback?.Invoke(new PresentCardCallbackParameter { CardData = data, RawData = rawData });
                }));
        }

        /// <summary>
        /// Will send a progress message to the connecting client.
        /// </summary>
        /// <param name="message"></param>
        public void Update(string message)
        {
            _deferrals.update(message);
        }

        public struct PresentCardCallbackParameter
        {
            /// <summary>
            /// A parsed version of the data sent from the card.
            /// </summary>
            public object CardData { get; set; }
            /// <summary>
            /// A JSON string containing the data sent from the card.
            /// </summary>
            public string RawData { get; set; }
        }
    }
}
