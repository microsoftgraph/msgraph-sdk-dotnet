This repository is used to capture generated code files. The code files are generated using microsoft/kiota. The primary purpose of the copilot reviewer is to identify any changes that can cause a regressions for an application that uses this library. You are required to create a comment anytime a code change occurs that changes an APIs signature in a way that is not additive.

- Use only tools, commands, and workflows that are available in this repository's context.
- Do not instruct contributors or users to enable external tools that are not defined or documented in this repository.
- When reviewing changes, prioritize identifying regressions and non-additive API signature changes in generated code.

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