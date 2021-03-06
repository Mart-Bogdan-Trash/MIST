﻿using System;

namespace Mathtone.MIST {

	/// <summary>
	/// Used to mark a property as a notification provider.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class NotifyAttribute : Attribute {
		public string[] NotificationSource { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyAttribute"/> class.
		/// </summary>
		/// <param name="sourceNames">Properties that will be passed to the cotification target method.</param>
		public NotifyAttribute(params string[] sourceNames) {
			NotificationSource = sourceNames;
		}
	}

	/// <summary>
	/// Used on public properties in implicit notification scenarios for which notificaiton should NOT be implemented.
	/// </summary>
	/// <seealso cref="System.Attribute" />
	[AttributeUsage(AttributeTargets.Property)]
	public class SuppressNotifyAttribute : Attribute {

	}

	/// <summary>
	/// Used to mark a class for automatic notification implementation;
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class NotifierAttribute : Attribute {

		public NotificationMode NotificationMode { get; protected set; }

		public NotifierAttribute(NotificationMode mode = NotificationMode.Explicit) {
			this.NotificationMode = mode;
		}
	}

	/// <summary>
	/// Used to identify the notification target method.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class NotifyTarget : Attribute {

	}

	/// <summary>
	/// Use implicit or explicit implementation of notification;
	/// </summary>
	public enum NotificationMode {

		/// <summary>
		/// Properties must be marked with the <see cref="NotifyAttribute"/>
		/// </summary>
		Explicit,

		/// <summary>
		/// Notification will be implemented for all public properties declared within the class;
		/// </summary>
		Implicit
	}
}