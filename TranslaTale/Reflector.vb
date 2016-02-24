
Imports System.Reflection

Namespace FolderSelect
    ''' <summary>
    ''' This class is from the Front-End for Dosbox and is used to present a 'vista' dialog box to select folders.
    ''' Being able to use a vista style dialog box to select folders is much better then using the shell folder browser.
    ''' http://code.google.com/p/fed/
    '''
    ''' Example:
    ''' var r = new Reflector("System.Windows.Forms");
    ''' </summary>
    Public Class Reflector
#Region "variables"

        Private m_ns As String
        Private m_asmb As Assembly

#End Region

#Region "Constructors"

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="ns">The namespace containing types to be used</param>
        Public Sub New(ns As String)
            Me.New(ns, ns)
        End Sub

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="an__1">A specific assembly name (used if the assembly name does not tie exactly with the namespace)</param>
        ''' <param name="ns">The namespace containing types to be used</param>
        Public Sub New(an__1 As String, ns As String)
            m_ns = ns
            m_asmb = Nothing
            For Each aN__2 As AssemblyName In Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                If aN__2.FullName.StartsWith(an__1) Then
                    m_asmb = Assembly.Load(aN__2)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' Return a Type instance for a type 'typeName'
        ''' </summary>
        ''' <param name="typeName">The name of the type</param>
        ''' <returns>A type instance</returns>
        Public Overloads Function [GetType](typeName As String) As Type
            Dim type As Type = Nothing
            Dim names As String() = typeName.Split("."c)

            If names.Length > 0 Then
                type = m_asmb.[GetType]((m_ns & Convert.ToString(".")) + names(0))
            End If

            For i As Integer = 1 To names.Length - 1
                type = type.GetNestedType(names(i), BindingFlags.NonPublic)
            Next
            Return type
        End Function

        ''' <summary>
        ''' Create a new object of a named type passing along any params
        ''' </summary>
        ''' <param name="name">The name of the type to create</param>
        ''' <param name="parameters"></param>
        ''' <returns>An instantiated type</returns>
        Public Function [New](name As String, ParamArray parameters As Object()) As Object
            Dim type As Type = [GetType](name)

            Dim ctorInfos As ConstructorInfo() = type.GetConstructors()
            For Each ci As ConstructorInfo In ctorInfos
                Try
                    Return ci.Invoke(parameters)
                Catch
                End Try
            Next

            Return Nothing
        End Function

        ''' <summary>
        ''' Calls method 'func' on object 'obj' passing parameters 'parameters'
        ''' </summary>
        ''' <param name="obj">The object on which to excute function 'func'</param>
        ''' <param name="func">The function to execute</param>
        ''' <param name="parameters">The parameters to pass to function 'func'</param>
        ''' <returns>The result of the function invocation</returns>
        Public Function [Call](obj As Object, func As String, ParamArray parameters As Object()) As Object
            Return Call2(obj, func, parameters)
        End Function

        ''' <summary>
        ''' Calls method 'func' on object 'obj' passing parameters 'parameters'
        ''' </summary>
        ''' <param name="obj">The object on which to excute function 'func'</param>
        ''' <param name="func">The function to execute</param>
        ''' <param name="parameters">The parameters to pass to function 'func'</param>
        ''' <returns>The result of the function invocation</returns>
        Public Function Call2(obj As Object, func As String, parameters As Object()) As Object
            Return CallAs2(obj.[GetType](), obj, func, parameters)
        End Function

        ''' <summary>
        ''' Calls method 'func' on object 'obj' which is of type 'type' passing parameters 'parameters'
        ''' </summary>
        ''' <param name="type">The type of 'obj'</param>
        ''' <param name="obj">The object on which to excute function 'func'</param>
        ''' <param name="func">The function to execute</param>
        ''' <param name="parameters">The parameters to pass to function 'func'</param>
        ''' <returns>The result of the function invocation</returns>
        Public Function CallAs(type As Type, obj As Object, func As String, ParamArray parameters As Object()) As Object
            Return CallAs2(type, obj, func, parameters)
        End Function

        ''' <summary>
        ''' Calls method 'func' on object 'obj' which is of type 'type' passing parameters 'parameters'
        ''' </summary>
        ''' <param name="type">The type of 'obj'</param>
        ''' <param name="obj">The object on which to excute function 'func'</param>
        ''' <param name="func">The function to execute</param>
        ''' <param name="parameters">The parameters to pass to function 'func'</param>
        ''' <returns>The result of the function invocation</returns>
        Public Function CallAs2(type As Type, obj As Object, func As String, parameters As Object()) As Object
            Dim methInfo As MethodInfo = type.GetMethod(func, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
            Return methInfo.Invoke(obj, parameters)
        End Function

        ''' <summary>
        ''' Returns the value of property 'prop' of object 'obj'
        ''' </summary>
        ''' <param name="obj">The object containing 'prop'</param>
        ''' <param name="prop">The property name</param>
        ''' <returns>The property value</returns>
        Public Function [Get](obj As Object, prop As String) As Object
            Return GetAs(obj.[GetType](), obj, prop)
        End Function

        ''' <summary>
        ''' Returns the value of property 'prop' of object 'obj' which has type 'type'
        ''' </summary>
        ''' <param name="type">The type of 'obj'</param>
        ''' <param name="obj">The object containing 'prop'</param>
        ''' <param name="prop">The property name</param>
        ''' <returns>The property value</returns>
        Public Function GetAs(type As Type, obj As Object, prop As String) As Object
            Dim propInfo As PropertyInfo = type.GetProperty(prop, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
            Return propInfo.GetValue(obj, Nothing)
        End Function

        ''' <summary>
        ''' Returns an enum value
        ''' </summary>
        ''' <param name="typeName">The name of enum type</param>
        ''' <param name="name">The name of the value</param>
        ''' <returns>The enum value</returns>
        Public Function GetEnum(typeName As String, name As String) As Object
            Dim type As Type = [GetType](typeName)
            Dim fieldInfo As FieldInfo = type.GetField(name)
            Return fieldInfo.GetValue(Nothing)
        End Function

#End Region

    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
