﻿namespace Tilia.Interactions.PointerInteractors
{
    using Malimbe.BehaviourStateRequirementMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using Tilia.Interactions.Interactables.Interactables;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// Attempts to grab the given Interactable to the given Interactor.
    /// </summary>
    public class InteractableGrabber : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractableFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractableFacade> { }

        /// <summary>
        /// The Interactor to grab to.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public InteractorFacade Interactor { get; set; }
        /// <summary>
        /// The Interactable to grab.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public InteractableFacade Interactable { get; set; }

        /// <summary>
        /// Emitted when the Grab has occurred.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Grabbed = new UnityEvent();

        /// <summary>
        /// Attempts to grab the <see cref="Interactable"/> to the <see cref="Interactor"/>.
        /// </summary>
        [RequiresBehaviourState]
        public virtual void DoGrab()
        {
            if (Interactor == null || Interactable == null)
            {
                return;
            }

            Interactable.Ungrab();

            Interactor.Grab(Interactable);
            Grabbed?.Invoke(Interactable);
        }
    }
}