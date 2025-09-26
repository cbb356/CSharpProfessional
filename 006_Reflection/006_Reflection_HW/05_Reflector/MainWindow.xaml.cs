using Microsoft.Win32;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflector
{
    public partial class MainWindow : Window
    {
        private Assembly currentAssembly;

        public MainWindow()
        {
            InitializeComponent();
            statusText.Text = "Ready. Load an assembly to begin reflection.";
        }

        private void LoadAssembly_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Assembly Files (*.dll;*.exe)|*.dll;*.exe|All Files (*.*)|*.*",
                Title = "Select Assembly to Load"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                LoadAssembly(openFileDialog.FileName);
            }
        }

        private void LoadAssembly(string filePath)
        {
            try
            {
                statusText.Text = "Loading assembly...";
                treeAssembly.Items.Clear();
                txtDetails.Text = "";

                // Load assembly
                currentAssembly = Assembly.LoadFrom(filePath);

                // Create root node
                TreeViewItem assemblyNode = new TreeViewItem
                {
                    Header = $"📦 {currentAssembly.GetName().Name}",
                    Tag = currentAssembly
                };

                // Add assembly info
                TreeViewItem infoNode = new TreeViewItem
                {
                    Header = "ℹ️ Assembly Information",
                    Tag = new AssemblyInfo(currentAssembly)
                };
                assemblyNode.Items.Add(infoNode);

                // Add namespaces
                var types = currentAssembly.GetTypes().OrderBy(t => t.Namespace ?? "").ThenBy(t => t.Name);
                var namespaces = types.GroupBy(t => t.Namespace ?? "<Global>").OrderBy(g => g.Key);

                foreach (var namespaceGroup in namespaces)
                {
                    TreeViewItem namespaceNode = new TreeViewItem
                    {
                        Header = $"📁 {namespaceGroup.Key}",
                        Tag = namespaceGroup.Key
                    };

                    foreach (var type in namespaceGroup.OrderBy(t => t.Name))
                    {
                        TreeViewItem typeNode = CreateTypeNode(type);
                        namespaceNode.Items.Add(typeNode);
                    }

                    assemblyNode.Items.Add(namespaceNode);
                }

                treeAssembly.Items.Add(assemblyNode);
                assemblyNode.IsExpanded = true;

                //statusText.Text = $"Loaded: {Path.tFileName(filePath)} ({types.Count()} types)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading assembly:\n{ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                statusText.Text = "Error loading assembly";
            }
        }

        private TreeViewItem CreateTypeNode(Type type)
        {
            string icon = GetTypeIcon(type);
            TreeViewItem typeNode = new TreeViewItem
            {
                Header = $"{icon} {type.Name}",
                Tag = type
            };

            // Add constructors
            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (constructors.Length > 0)
            {
                TreeViewItem constructorsNode = new TreeViewItem
                {
                    Header = $"🔨 Constructors ({constructors.Length})",
                    Tag = new MemberGroup("Constructors", constructors)
                };
                typeNode.Items.Add(constructorsNode);
            }

            // Add properties
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (properties.Length > 0)
            {
                TreeViewItem propertiesNode = new TreeViewItem
                {
                    Header = $"🏠 Properties ({properties.Length})",
                    Tag = new MemberGroup("Properties", properties)
                };
                typeNode.Items.Add(propertiesNode);
            }

            // Add methods
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                             .Where(m => !m.IsSpecialName).ToArray();
            if (methods.Length > 0)
            {
                TreeViewItem methodsNode = new TreeViewItem
                {
                    Header = $"⚙️ Methods ({methods.Length})",
                    Tag = new MemberGroup("Methods", methods)
                };
                typeNode.Items.Add(methodsNode);
            }

            // Add fields
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (fields.Length > 0)
            {
                TreeViewItem fieldsNode = new TreeViewItem
                {
                    Header = $"📋 Fields ({fields.Length})",
                    Tag = new MemberGroup("Fields", fields)
                };
                typeNode.Items.Add(fieldsNode);
            }

            // Add events
            var events = type.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (events.Length > 0)
            {
                TreeViewItem eventsNode = new TreeViewItem
                {
                    Header = $"⚡ Events ({events.Length})",
                    Tag = new MemberGroup("Events", events)
                };
                typeNode.Items.Add(eventsNode);
            }

            // Add nested types
            var nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
            if (nestedTypes.Length > 0)
            {
                TreeViewItem nestedTypesNode = new TreeViewItem
                {
                    Header = $"📦 Nested Types ({nestedTypes.Length})",
                    Tag = new MemberGroup("NestedTypes", nestedTypes)
                };
                typeNode.Items.Add(nestedTypesNode);
            }

            return typeNode;
        }

        private string GetTypeIcon(Type type)
        {
            if (type.IsInterface) return "🔌";
            if (type.IsEnum) return "📝";
            if (type.IsValueType) return "💎";
            if (type.IsAbstract) return "🎭";
            if (type.IsSealed) return "🔒";
            return "🏛️";
        }

        private void TreeAssembly_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem selectedItem)
            {
                ShowDetails(selectedItem.Tag);
            }
        }

        private void ShowDetails(object item)
        {
            StringBuilder details = new StringBuilder();

            try
            {
                switch (item)
                {
                    case Assembly assembly:
                        ShowAssemblyDetails(assembly, details);
                        break;
                    case AssemblyInfo assemblyInfo:
                        ShowAssemblyInfoDetails(assemblyInfo, details);
                        break;
                    case Type type:
                        ShowTypeDetails(type, details);
                        break;
                    case MemberGroup memberGroup:
                        ShowMemberGroupDetails(memberGroup, details);
                        break;
                    case string ns when item.ToString().StartsWith("📁"):
                        details.AppendLine($"Namespace: {ns}");
                        details.AppendLine($"Types in this namespace: {currentAssembly.GetTypes().Count(t => (t.Namespace ?? "<Global>") == ns)}");
                        break;
                    default:
                        details.AppendLine("Select an item to view details.");
                        break;
                }

                txtDetails.Text = details.ToString();
            }
            catch (Exception ex)
            {
                txtDetails.Text = $"Error displaying details: {ex.Message}";
            }
        }

        private void ShowAssemblyDetails(Assembly assembly, StringBuilder details)
        {
            details.AppendLine($"Assembly: {assembly.GetName().Name}");
            details.AppendLine($"Version: {assembly.GetName().Version}");
            details.AppendLine($"Location: {assembly.Location}");
            details.AppendLine($"Full Name: {assembly.FullName}");
            details.AppendLine($"Runtime Version: {assembly.ImageRuntimeVersion}");
            details.AppendLine($"Global Assembly Cache: {assembly.GlobalAssemblyCache}");
            details.AppendLine();
            details.AppendLine($"Total Types: {assembly.GetTypes().Length}");
            details.AppendLine($"Public Types: {assembly.GetExportedTypes().Length}");
        }

        private void ShowAssemblyInfoDetails(AssemblyInfo assemblyInfo, StringBuilder details)
        {
            var assembly = assemblyInfo.Assembly;
            details.AppendLine("=== ASSEMBLY INFORMATION ===");
            details.AppendLine();

            details.AppendLine($"Name: {assembly.GetName().Name}");
            details.AppendLine($"Version: {assembly.GetName().Version}");
            details.AppendLine($"Culture: {assembly.GetName().CultureName ?? "neutral"}");
            details.AppendLine($"Public Key Token: {BitConverter.ToString(assembly.GetName().GetPublicKeyToken() ?? new byte[0]).Replace("-", "")}");
            details.AppendLine($"Location: {assembly.Location}");
            details.AppendLine($"CodeBase: {assembly.CodeBase}");
            details.AppendLine($"Runtime Version: {assembly.ImageRuntimeVersion}");
            details.AppendLine($"Global Assembly Cache: {assembly.GlobalAssemblyCache}");
            details.AppendLine();

            details.AppendLine("=== STATISTICS ===");
            var types = assembly.GetTypes();
            details.AppendLine($"Total Types: {types.Length}");
            details.AppendLine($"Public Types: {types.Count(t => t.IsPublic)}");
            details.AppendLine($"Classes: {types.Count(t => t.IsClass && !t.IsInterface)}");
            details.AppendLine($"Interfaces: {types.Count(t => t.IsInterface)}");
            details.AppendLine($"Enums: {types.Count(t => t.IsEnum)}");
            details.AppendLine($"Value Types: {types.Count(t => t.IsValueType && !t.IsEnum)}");
            details.AppendLine();

            // Custom attributes
            var customAttributes = assembly.GetCustomAttributes(false);
            if (customAttributes.Length > 0)
            {
                details.AppendLine("=== CUSTOM ATTRIBUTES ===");
                foreach (var attr in customAttributes)
                {
                    details.AppendLine($"[{attr.GetType().Name}]");
                }
            }
        }

        private void ShowTypeDetails(Type type, StringBuilder details)
        {
            details.AppendLine($"Type: {type.FullName}");
            details.AppendLine($"Assembly: {type.Assembly.GetName().Name}");
            details.AppendLine($"Namespace: {type.Namespace ?? "<Global>"}");
            details.AppendLine($"Base Type: {type.BaseType?.FullName ?? "None"}");
            details.AppendLine();

            details.AppendLine("=== TYPE CHARACTERISTICS ===");
            details.AppendLine($"Is Class: {type.IsClass}");
            details.AppendLine($"Is Interface: {type.IsInterface}");
            details.AppendLine($"Is Enum: {type.IsEnum}");
            details.AppendLine($"Is Value Type: {type.IsValueType}");
            details.AppendLine($"Is Abstract: {type.IsAbstract}");
            details.AppendLine($"Is Sealed: {type.IsSealed}");
            details.AppendLine($"Is Generic: {type.IsGenericType}");
            details.AppendLine($"Is Public: {type.IsPublic}");
            details.AppendLine();

            // Interfaces
            var interfaces = type.GetInterfaces();
            if (interfaces.Length > 0)
            {
                details.AppendLine("=== IMPLEMENTED INTERFACES ===");
                foreach (var iface in interfaces)
                {
                    details.AppendLine($"  {iface.Name}");
                }
                details.AppendLine();
            }

            // Generic parameters
            if (type.IsGenericType)
            {
                details.AppendLine("=== GENERIC PARAMETERS ===");
                foreach (var genericArg in type.GetGenericArguments())
                {
                    details.AppendLine($"  {genericArg.Name}");
                }
                details.AppendLine();
            }

            // Custom attributes
            var customAttributes = type.GetCustomAttributes(false);
            if (customAttributes.Length > 0)
            {
                details.AppendLine("=== CUSTOM ATTRIBUTES ===");
                foreach (var attr in customAttributes)
                {
                    details.AppendLine($"[{attr.GetType().Name}]");
                }
            }
        }

        private void ShowMemberGroupDetails(MemberGroup memberGroup, StringBuilder details)
        {
            details.AppendLine($"=== {memberGroup.GroupName.ToUpper()} ===");
            details.AppendLine();

            foreach (var member in memberGroup.Members)
            {
                switch (member)
                {
                    case ConstructorInfo ctor:
                        ShowConstructorDetails(ctor, details);
                        break;
                    case MethodInfo method:
                        ShowMethodDetails(method, details);
                        break;
                    case PropertyInfo property:
                        ShowPropertyDetails(property, details);
                        break;
                    case FieldInfo field:
                        ShowFieldDetails(field, details);
                        break;
                    case EventInfo eventInfo:
                        ShowEventDetails(eventInfo, details);
                        break;
                    case Type nestedType:
                        details.AppendLine($"{GetTypeIcon(nestedType)} {nestedType.Name}");
                        break;
                }
                details.AppendLine();
            }
        }

        private void ShowConstructorDetails(ConstructorInfo ctor, StringBuilder details)
        {
            details.Append($"🔨 {(ctor.IsPublic ? "public" : ctor.IsPrivate ? "private" : ctor.IsFamily ? "protected" : "internal")} ");
            details.Append($"{ctor.DeclaringType.Name}(");

            var parameters = ctor.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0) details.Append(", ");
                details.Append($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
            }
            details.AppendLine(")");
        }

        private void ShowMethodDetails(MethodInfo method, StringBuilder details)
        {
            details.Append($"⚙️ {(method.IsPublic ? "public" : method.IsPrivate ? "private" : method.IsFamily ? "protected" : "internal")} ");
            if (method.IsStatic) details.Append("static ");
            if (method.IsVirtual) details.Append("virtual ");
            if (method.IsAbstract) details.Append("abstract ");

            details.Append($"{method.ReturnType.Name} {method.Name}(");

            var parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0) details.Append(", ");
                details.Append($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
            }
            details.AppendLine(")");
        }

        private void ShowPropertyDetails(PropertyInfo property, StringBuilder details)
        {
            details.Append($"🏠 ");
            if (property.GetMethod?.IsPublic == true || property.SetMethod?.IsPublic == true) details.Append("public ");
            else if (property.GetMethod?.IsPrivate == true && property.SetMethod?.IsPrivate == true) details.Append("private ");
            else details.Append("protected/internal ");

            if (property.GetMethod?.IsStatic == true || property.SetMethod?.IsStatic == true) details.Append("static ");

            details.Append($"{property.PropertyType.Name} {property.Name} {{ ");
            if (property.CanRead) details.Append("get; ");
            if (property.CanWrite) details.Append("set; ");
            details.AppendLine("}");
        }

        private void ShowFieldDetails(FieldInfo field, StringBuilder details)
        {
            details.Append($"📋 {(field.IsPublic ? "public" : field.IsPrivate ? "private" : field.IsFamily ? "protected" : "internal")} ");
            if (field.IsStatic) details.Append("static ");
            //if (field.IsReadOnly) details.Append("readonly ");
            details.AppendLine($"{field.FieldType.Name} {field.Name}");
        }

        private void ShowEventDetails(EventInfo eventInfo, StringBuilder details)
        {
            details.AppendLine($"⚡ {eventInfo.EventHandlerType.Name} {eventInfo.Name}");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            treeAssembly.Items.Clear();
            txtDetails.Text = "";
            currentAssembly = null;
            statusText.Text = "Ready. Load an assembly to begin reflection.";
        }

        private void ExpandAll_Click(object sender, RoutedEventArgs e)
        {
            ExpandTreeViewItems(treeAssembly.Items, true);
        }

        private void CollapseAll_Click(object sender, RoutedEventArgs e)
        {
            ExpandTreeViewItems(treeAssembly.Items, false);
        }

        private void ExpandTreeViewItems(ItemCollection items, bool expand)
        {
            foreach (TreeViewItem item in items)
            {
                item.IsExpanded = expand;
                ExpandTreeViewItems(item.Items, expand);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Assembly Reflector v1.0\n\nA simple WPF application for exploring .NET assemblies using reflection.\n\nCreated with C# and WPF.",
                "About Assembly Reflector", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    // Helper classes
    public class AssemblyInfo
    {
        public Assembly Assembly { get; }
        public AssemblyInfo(Assembly assembly) => Assembly = assembly;
    }

    public class MemberGroup
    {
        public string GroupName { get; }
        public object[] Members { get; }
        public MemberGroup(string groupName, object[] members)
        {
            GroupName = groupName;
            Members = members;
        }
    }
}