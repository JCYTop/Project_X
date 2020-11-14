//#include <glad/glad.h>
//#include <GLFW/glfw3.h>
//#include <iostream>
//#include <shader_s.h>
//
//void framebuffer_size_callback(GLFWwindow* window, int width, int height);
//void processInput(GLFWwindow* window);
//
//// settings
//const unsigned int SCR_WIDTH = 800;
//const unsigned int SCR_HEIGHT = 600;
//
//const char* vertexShaderSource =
//"#version 330 core\n"
//"layout (location = 0) in vec3 aPos;\n"
//"layout (location = 1) in vec3 aColor;\n"
////"out vec4 vertexColor; // 为片段着色器指定一个颜色输出\n"
//"out vec3 ourColor; // 向片段着色器输出一个颜色\n"
//"void main()\n"
//"{\n"
//"	gl_Position = vec4(aPos, 1.0); // 注意我们如何把一个vec3作为vec4的构造器的参数\n"
////"	vertexColor = vec4(0.5, 0.0, 0.0, 1.0); // 把输出变量设置为暗红色\n"
//"	ourColor = aColor; // 将ourColor设置为我们从顶点数据那里得到的输入颜色\n"
//"}\0";
//
//const char* fragmentShaderSource =
//"#version 330 core\n"
//"out vec4 FragColor;\n"
////"in vec4 vertexColor; // 从顶点着色器传来的输入变量（名称相同、类型相同）\n"
////"uniform vec4 ourColor; // 在OpenGL程序代码中设定这个变量\n"
//"in vec3 ourColor;\n"
//"void main()\n"
//"{\n"
////"	FragColor = vertexColor;\n"
////"	FragColor = ourColor;"
//"	FragColor = vec4(ourColor, 1.0);\n"
//"}\n\0";
//
////int main()
////{
////	// glfw: initialize and configure
////	// ------------------------------
////	glfwInit();
////	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
////	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
////	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
////
////#ifdef __APPLE__
////	glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);
////#endif
////
////	// glfw window creation
////	// --------------------
////	GLFWwindow* window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "LearnOpenGL", NULL, NULL);
////	if (window == NULL)
////	{
////		std::cout << "Failed to create GLFW window" << std::endl;
////		glfwTerminate();
////		return -1;
////	}
////	glfwMakeContextCurrent(window);
////	glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);
////	// glad: load all OpenGL function pointers
////	// ---------------------------------------
////	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
////	{
////		std::cout << "Failed to initialize GLAD" << std::endl;
////		return -1;
////	}
////
////	// build and compile our shader program
////	// ------------------------------------
////	Shader ourShader("3.3.shader.vs", "3.3.shader.fs"); // you can name your shader files however you like
////
////	// set up vertex data (and buffer(s)) and configure vertex attributes
////	// ------------------------------------------------------------------
////	float vertices[] = {
////		//-0.5f, -0.5f, 0.0f, // left  
////		// 0.5f, -0.5f, 0.0f, // right 
////		// 0.0f,  0.5f, 0.0f  // top   
////		//0.5f, 0.5f, 0.0f,   // 右上角
////		//0.5f, -0.5f, 0.0f,  // 右下角
////		//-0.5f, -0.5f, 0.0f, // 左下角
////		//-0.5f, 0.5f, 0.0f   // 左上角
////		// 位置              // 颜色
////		0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f,   // 右下
////		-0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f,   // 左下
////		0.0f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f    // 顶部
////	};
////	//unsigned int indices[] = { // 注意索引从0开始! 
////	//0, 1, 3, // 第一个三角形
////	//1, 2, 3  // 第二个三角形
////	//};
////
////	unsigned int VBO, VAO;
////	glGenVertexArrays(1, &VAO);
////	glGenBuffers(1, &VBO);
////	// bind the Vertex Array Object first, then bind and set vertex buffer(s), and then configure vertex attributes(s).
////	glBindVertexArray(VAO);
////
////	glBindBuffer(GL_ARRAY_BUFFER, VBO);
////	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);
////
////	// position attribute
////	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)0);
////	glEnableVertexAttribArray(0);
////	// color attribute
////	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(float), (void*)(3 * sizeof(float)));
////	glEnableVertexAttribArray(1);
////
////	// You can unbind the VAO afterwards so other VAO calls won't accidentally modify this VAO, but this rarely happens. Modifying other
////	// VAOs requires a call to glBindVertexArray anyways so we generally don't unbind VAOs (nor VBOs) when it's not directly necessary.
////	// glBindVertexArray(0);
////
////	// render loop
////	// -----------
////	while (!glfwWindowShouldClose(window))
////	{
////		// input
////		// -----
////		processInput(window);
////
////		// render
////		// ------
////		glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
////		glClear(GL_COLOR_BUFFER_BIT);
////
////		// render the triangle
////		ourShader.use();
////		glBindVertexArray(VAO);
////		glDrawArrays(GL_TRIANGLES, 0, 3);
////
////		//使用uniform定义一个水平偏移量，在顶点着色器中使用这个偏移量把三角形移动到屏幕右侧
////		/*float offset = 0.5;
////		ourShader.setFloat("xOffset", offset);*/
////
////		// glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
////		// -------------------------------------------------------------------------------
////		glfwSwapBuffers(window);
////		glfwPollEvents();
////	}
////
////	// optional: de-allocate all resources once they've outlived their purpose:
////	// ------------------------------------------------------------------------
////	glDeleteVertexArrays(1, &VAO);
////	glDeleteBuffers(1, &VBO);
////
////	// glfw: terminate, clearing all previously allocated GLFW resources.
////	// ------------------------------------------------------------------
////	glfwTerminate();
////	return 0;
////}
//
//// process all input: query GLFW whether relevant keys are pressed/released this frame and react accordingly
//// ---------------------------------------------------------------------------------------------------------
//void processInput(GLFWwindow* window)
//{
//	if (glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
//		glfwSetWindowShouldClose(window, true);
//}
//
//// glfw: whenever the window size changed (by OS or user resize) this callback function executes
//// ---------------------------------------------------------------------------------------------
//void framebuffer_size_callback(GLFWwindow* window, int width, int height)
//{
//	// make sure the viewport matches the new window dimensions; note that width and 
//	// height will be significantly larger than specified on retina displays.
//	glViewport(0, 0, width, height);
//}