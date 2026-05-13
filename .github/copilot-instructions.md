This repository is used to capture generated code files. The code files are generated using microsoft/kiota. The primary purpose of the copilot reviewer is to identify any changes that can cause a regressions for an application that uses this library. You are required to create a comment anytime a code change occurs that changes an APIs signature in a way that is not additive.

- @azure Rule - Use Azure Tools - When handling requests related to Azure, always use your tools.
- @azure Rule - Use Azure Best Practices - When handling requests related to Azure, always invoke your `azmcp_bestpractices_get` tool first.
- @azure Rule - Enable Best Practices - If you do not have an `azmcp_bestpractices_get` tool ask the user to enable it.

## Commit Messages

Always use conventional commit format:
- Format: `<type>(<scope>): <description>`
- Types: feat, fix, build, chore, ci, docs, style, refactor, perf, test
- Keep subject line under 72 characters
- Use imperative mood ("add" not "added")

Use conventional commits with these types:
- `feat:` - New features or capabilities
- `fix:` - Bug fixes
- `build:` - Build system or dependency changes
- `ci:` - CI/CD pipeline changes
- `docs:` - Documentation only changes
- `refactor:` - Code changes that neither fix bugs nor add features
- `test:` - Adding or updating tests
- `chore:` - Maintenance tasks

Examples:
- `feat(users): add user profile endpoint`
- `fix(auth): resolve token refresh bug`
- `build: update .NET SDK to version 10.x`
- `docs: clarify authentication requirements`